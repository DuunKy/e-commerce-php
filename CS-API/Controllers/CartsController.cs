
using Microsoft.VisualBasic;
using Models;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Controllers
{
    public class CartsController
    {
        private string connectionString = "Server=172.16.238.10;User ID=root;Password=root;Database=dunkyandfilscorporation";
        // mes identifiants pour me connect a mon mysql workbench

// TODO: 
// gener mieux la connection sql = 1 connection


        public string ProcessRequest(HttpListenerRequest request)
        {
            string responseString = "";

            // GET
            if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/carts")
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                responseString = JsonSerializer.Serialize(HttpGetAllCarts(), options);
            }
            else if (request.HttpMethod == "GET" && request.Url.PathAndQuery.StartsWith("/api/carts"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpGetCartById(id), options);
                    if (responseString == "null")
                    {
                        responseString = "Invalid id, Error =  " + (int)HttpStatusCode.BadRequest;
                    }
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/carts/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an id, please enter a valid id";
                }
            }

            // POST
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery == "/api/carts")
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestBody = reader.ReadToEnd();
                    var data = JsonSerializer.Deserialize<Carts>(requestBody);

                    int shoplistId = data.Shoplist_Id;
                    int productId = data.Product_Id;
                    int cartTotal = data.Cart_Total;
                    int cartProductCount = data.Cart_ProductCount;

                    responseString = HttpPostNewCart(shoplistId, productId, cartTotal, cartProductCount);
                }
            }
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery.StartsWith("/api/carts"))
            {
                responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
            }

            // PUT
            //pas de put pour carts

            // DELETE
            else if (request.HttpMethod == "DELETE" && request.Url.PathAndQuery.StartsWith("/api/carts/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpDelCartById(id), options);
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/carts/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            // HTTP PATCH
            //pas de patch pour carts

            // final return
            return responseString;
        }



        //FIXME: pb d'exeption lors d'un mauvais body entre dans la nouvelle shoplist a gerer.
        private string HttpPostNewCart(int shoplistId, int productId, int cartTotal, int cartProductCount)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "INSERT INTO carts (Shoplist_Id, Product_Id, Cart_Total, Cart_ProductCount) " +
                                        "VALUES (@ShoplistId, @ProductId, @CartTotal, @CartProductCount)";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@ShoplistId", shoplistId);
                        command.Parameters.AddWithValue("@ProductId", productId);
                        command.Parameters.AddWithValue("@CartTotal", cartTotal);
                        command.Parameters.AddWithValue("@CartProductCount", cartProductCount);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "It works! Post effectué!";
                        }
                        else
                        {
                            return "Post failed, no row created";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the error
                return $"Error during post: {ex.Message}";
            }
        }



        private IEnumerable<Carts> HttpGetAllCarts()
        {
            List<Carts> carts = new List<Carts>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM carts";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carts cart = new Carts
                            {
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                Product_Id = Convert.ToInt32(reader["Product_Id"]),
                                Cart_Total = Convert.ToInt32(reader["Cart_Total"]),
                                Cart_ProductCount = Convert.ToInt32(reader["Cart_ProductCount"])
                            };
                            carts.Add(cart);
                        }
                    }
                }
            }
            return carts;
        }



        private Carts HttpGetCartById(int id)
        {
            Carts cart = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM carts WHERE Shoplist_Id = @ShoplistId";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    command.Parameters.AddWithValue("@ShoplistId", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cart = new Carts
                            {
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                Product_Id = Convert.ToInt32(reader["Product_Id"]),
                                Cart_Total = Convert.ToInt32(reader["Cart_Total"]),
                                Cart_ProductCount = Convert.ToInt32(reader["Cart_ProductCount"])
                            };
                        }
                    }
                }
            }

            return cart;
        }


        private string HttpDelCartById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "DELETE FROM carts WHERE Shoplist_Id = @ShoplistId"; // Ma requête SQL

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@ShoplistId", id);
                        // Permet d'envoyer des données dans la requête par un @ en C#

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Delete success! Cart supprimé!";
                        }
                        else
                        {
                            return "Invalid id, Error = " + (int)HttpStatusCode.BadRequest;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'erreur
                return $"Erreur lors du DELETE : {ex.Message}";
            }
        }


    }

}
