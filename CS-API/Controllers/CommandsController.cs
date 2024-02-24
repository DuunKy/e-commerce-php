
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
    public class CommandsController
    {
        private string connectionString = "Server=172.16.238.10;User ID=root;Password=root;Database=dunkyandfilscorporation";
        // mes identifiants pour me connect a mon mysql workbench

// TODO: 
// gener mieux la connection sql = 1 connection


        public string ProcessRequest(HttpListenerRequest request)
        {
            string responseString = "";

            // GET
            if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/commands")
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                responseString = JsonSerializer.Serialize(HttpGetAllCommands(), options);
            }
            else if (request.HttpMethod == "GET" && request.Url.PathAndQuery.StartsWith("/api/commands"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpGetCommandById(id), options);
                    if (responseString == "null")
                    {
                        responseString = "Invalid id, Error =  " + (int)HttpStatusCode.BadRequest;
                    }
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/commands/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an id, please enter a valid id";
                }
            }

            // POST
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery == "/api/commands")
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestBody = reader.ReadToEnd();
                    var data = JsonSerializer.Deserialize<Commands>(requestBody);

                    int shoplistId = data.Shoplist_Id;
                    string orderDate = data.Command_OrderDate;

                    responseString = HttpPostNewCommand(shoplistId, orderDate);
                }
            }
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery.StartsWith("/api/commands"))
            {
                responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
            }

            // PUT
            // No PUT for commands

            // DELETE
            else if (request.HttpMethod == "DELETE" && request.Url.PathAndQuery.StartsWith("/api/commands/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpDelCommandById(id), options);
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/commands/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            // HTTP PATCH
            // No PATCH for commands

            // final return
            return responseString;
        }



        //FIXME: pb d'exeption lors d'un mauvais body entre dans la nouvelle shoplist a gerer.
        private string HttpPostNewCommand(int shoplistId, string orderDate)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "INSERT INTO commands (Shoplist_Id, Command_OrderDate) " +
                                        "VALUES (@ShoplistId, @OrderDate)";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@ShoplistId", shoplistId);
                        command.Parameters.AddWithValue("@OrderDate", orderDate);

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

        private IEnumerable<Commands> HttpGetAllCommands()
        {
            List<Commands> commands = new List<Commands>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM commands";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Commands commande = new Commands
                            {
                                Command_Id = Convert.ToInt32(reader["Command_Id"]),
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                Command_OrderDate = Convert.ToString(reader["Command_OrderDate"])
                            };
                            commands.Add(commande);
                        }
                    }
                }
            }
            return commands;
        }

        private Commands HttpGetCommandById(int id)
        {
            Commands commande = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM commands WHERE Command_Id = @CommandId";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    command.Parameters.AddWithValue("@CommandId", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commande = new Commands
                            {
                                Command_Id = Convert.ToInt32(reader["Command_Id"]),
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                Command_OrderDate = Convert.ToString(reader["Command_OrderDate"])
                            };
                        }
                    }
                }
            }

            return commande;
        }

        private string HttpDelCommandById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "DELETE FROM commands WHERE Command_Id = @CommandId";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@CommandId", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Delete success! Command supprimé!";
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
