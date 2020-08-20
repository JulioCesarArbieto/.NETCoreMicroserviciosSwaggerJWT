using CONTINER.API.MANAGER.Cross.Jwt;
using CONTINER.API.MANAGER.Cross.Jwt.Jwt;
using CONTINER.API.MANAGER.Cross.Proxy.Proxy;
using CONTINER.API.MANAGER.Withdrawal.DTO;
using CONTINER.API.MANAGER.Withdrawal.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Withdrawal.Service
{
    public class ServiceAccount : IServiceAccount
    {
        private readonly IConfiguration configuration;
        private readonly IHttpClient httpClient;
        private readonly IServiceTransaction serviceTransaction;
        private readonly JwtOptions jwtOption;

        public ServiceAccount(
            IConfiguration configuration,
            IHttpClient httpClient,
            IOptionsSnapshot<JwtOptions> jwtOption,
            IServiceTransaction serviceTransaction)
        {
            this.configuration = configuration;
            this.httpClient = httpClient;
            this.serviceTransaction = serviceTransaction;
            this.jwtOption = jwtOption.Value;

        }

        public async Task<bool> WithdrawalAccount(AccountRequest request)
        {
            string uri = configuration["proxy:urlAccountWithdrawal"];
            string token = "Bearer " + JwtToken.Create(jwtOption);
            var response = await httpClient.PostAsync(uri, request, token);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public bool WithdrawalReverse(Transaction request)
        {
            serviceTransaction.WithdrawalReverse(request);
            return true;
        }

        public bool Execute(Transaction request)
        {
            bool response = false;

            var circuitBreakerPolicy = Policy.Handle<Exception>().
                CircuitBreaker(3, TimeSpan.FromSeconds(15),
                onBreak: (ex, timespan, context) =>
                {
                    Console.WriteLine("El circuito entró en estado de falla");
                }, onReset: (context) =>
                {
                    Console.WriteLine("Circuito dejó estado de falla");
                });

            var retry = Policy.Handle<Exception>()
                           .WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300))
                           .Wrap(circuitBreakerPolicy);

            retry.Execute(() =>
            {
                //if (circuitBreakerPolicy.CircuitState != CircuitState.Open)
                if(circuitBreakerPolicy.CircuitState == CircuitState.Closed)
                {
                    circuitBreakerPolicy.Execute(() =>
                    {
                        AccountRequest account = new AccountRequest()
                        {
                            Amount = request.Amount,
                            IdAccount = request.AccountId
                        };
                        response = WithdrawalAccount(account).Result;
                        Console.WriteLine("Solicitud realizada con éxito");

                    });
                }

                if(circuitBreakerPolicy.CircuitState != CircuitState.Closed)
                {
                    Transaction transaction = new Transaction()
                    {
                        AccountId = request.AccountId,
                        Amount = request.Amount,
                        CreationDate = DateTime.Now.ToShortDateString(),
                        Type = "With R"
                    };
                    response = WithdrawalReverse(transaction);
                }
            });


            return response;
        }
    }
}
