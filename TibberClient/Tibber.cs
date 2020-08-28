using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using GraphQL;

// This example uses https://github.com/graphql-dotnet/graphql-client

using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace TibberClient
{
    public class Tibber
    {
        public Tibber(string authorizationToken)
        {
            this.AuthorizationToken = authorizationToken;
        }

        public string AuthorizationToken { get; private set; }



        public GraphQLHttpClient AuthorizedGraphQLClient
        {
            get
            {
                var client = new System.Net.Http.HttpClient();
                // Check https://help.smartweb.dk/authentication/ for information about how to obtain the access token
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                    $"{this.AuthorizationToken}");


                var options = new GraphQLHttpClientOptions()
                {
                    EndPoint = new Uri("https://api.tibber.com/v1-beta/gql")
                };
                // Set up the client
                var graphQLClient = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer(), client);
                return graphQLClient;
            }
        }

        private GraphQLRequest PriceListRequest(string homeId)
        {
            var priceListQuery =
                "query {" +
                "  viewer {" +
                "     userId" +
                "     name" +
                "     home(id: \"" + homeId + "\") {" +
                "      id" +
                "      subscriptions {" +
                "        id" +
                "        priceInfo" +
                "         {" +
                "          today {" +
                "            total" +
                "            energy" +
                "            tax" +
                "            startsAt" +
                "            currency" +
                "            level" +
                "          }" +
                "        }" +
                "      }" +
                "    }" +
                "  }" +
                "}";
            var priceListRequest = new GraphQLRequest(priceListQuery);
            return priceListRequest;
        }

        public async Task<GraphQLResponse<ResponseType>> GetPriceListAsync(string homeId)
        {
            var priceListRequest = this.PriceListRequest(homeId);
           // Send the request and store the response as an OrderResponse object
           try
           {
               var graphQLResponse = await this.AuthorizedGraphQLClient.SendQueryAsync<ResponseType>(priceListRequest);
                return graphQLResponse;
            }
           catch (Exception e)
           {
               throw;
           }


        }


    }
}

