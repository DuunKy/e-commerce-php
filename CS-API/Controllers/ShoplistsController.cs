
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
    public class ShoplistsController
    {
        private string connectionString = "Server=172.16.238.10;User ID=root;Password=root;Database=dunkyandfilscorporation";
        // mes identifiants pour me connect a mon mysql workbench

// TODO: 
// gener mieux la connection sql = 1 connection


        public string ProcessRequest(HttpListenerRequest request)
        {
            string responseString = "";

            //GET

            if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/shoplists")
            {
                var options = new JsonSerializerOptions { WriteIndented = true }; //cette ligne rend le json html jolie
                responseString = JsonSerializer.Serialize(HttpGetAllShoplists(), options);
            }
            else if (request.HttpMethod == "GET" && request.Url.PathAndQuery.StartsWith("/api/shoplists"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings; // separe notre url sur les "/"
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true }; //cette ligne rend le json html jolie
                    responseString = JsonSerializer.Serialize(HttpGetShoplistById(id), options);
                    if (responseString == "null")
                    {
                    responseString = "Invalid id, Error =  " + (int)HttpStatusCode.BadRequest;
                    }

                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/shoplists/")
                {
                    responseString = "enter a id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not a id, please enter a valid id";
                }

            }

            // POST


            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery == "/api/shoplists")
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestBody = reader.ReadToEnd(); // permet de lire le body de la requete postman json
                    var data = JsonSerializer.Deserialize<Shoplists>(requestBody); //ici data accede au body

                    int userId = data.User_Id;

                    responseString = HttpPostNewShoplist(userId);
                }
            }
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery.StartsWith("/api/shoplists"))
            {
                responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
            }


            //PUT

            else if (request.HttpMethod == "PUT" && request.Url.PathAndQuery.StartsWith("/api/shoplists/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings; // separe notre url sur les "/"
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    try
                    {
                        using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                        {
                            string requestBody = reader.ReadToEnd(); // permet de lire le body de la requete postman json
                            var data = JsonSerializer.Deserialize<Shoplists>(requestBody); //ici data accede au body

                            int userId = data.User_Id;

                            
                            var options = new JsonSerializerOptions { WriteIndented = true }; //cette ligne rend le json html jolie
                            responseString = JsonSerializer.Serialize(HttpPutShoplistById(id, userId), options);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Gérer l'erreur
                        return $"no or bad body send: {ex.Message}";
                    }
                    
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/shoplists/")
                {
                    responseString = "enter a id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not a Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            //DELETE

            else if (request.HttpMethod == "DELETE" && request.Url.PathAndQuery.StartsWith("/api/shoplists/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings; // separe notre url sur les "/"
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true }; //cette ligne rend le json html jolie
                    responseString = JsonSerializer.Serialize(HttpDelShoplistById(id), options);

                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/shoplists/")
                {
                    responseString = "enter a id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not a Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            // HTTP PATCH


            else if (request.HttpMethod == "PATCH" && request.Url.PathAndQuery.StartsWith("/api/shoplists/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings; // sépare notre URL sur les "/"
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {

                    try
                    {
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        string requestBody = reader.ReadToEnd(); // permet de lire le body de la requete postman json
                        var data = JsonSerializer.Deserialize<Shoplists>(requestBody); //ici data accede au body
                        
                            int userId = data.User_Id;


                        if (userId == null)
                        {
                            responseString = "bad body";
                        }
                        else
                        {
                            var options = new JsonSerializerOptions { WriteIndented = true };
                            responseString = JsonSerializer.Serialize(HttpPatchShoplistById(id, userId), options);
                        }
                    }
                    }
                    catch (Exception ex)
                    {
                        // Gérer l'erreur
                        return $"no or bad body send: {ex.Message}";
                    }
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/shoplists/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            //final return
            return responseString;
        }







        private string HttpPatchShoplistById(int id, int userId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // cette requete permet de mettre a jour seulement les champs non vide
                    string SqlRequest = "UPDATE shoplists SET ";

                    List<string> updates = new List<string>();

                    string ToStringUserId = userId.ToString();

                    if (!string.IsNullOrEmpty(ToStringUserId))
                    {
                        updates.Add("User_Id = @UserId");
                    }

                    SqlRequest += string.Join(", ", updates);
                    SqlRequest += " WHERE Shoplist_Id = @ShoplistId";

                    //ici on fait des collages pour avoir notre requete sql

                    Console.WriteLine(SqlRequest);

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@ShoplistId", id);
                        command.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Patch success! Product updated!";
                        }
                        else
                        {
                            return "Invalid id or no rows affected.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer l'erreur
                return $"Error during PATCH: {ex.Message}";
            }
        }

        //FIXME: pb d'exeption lors d'un mauvais body entre dans la nouvelle shoplist a gerer.
        private string HttpPostNewShoplist(int userId)
        {
            // sur postman, faire la requete avec un body contenant les infos ci dessus
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "INSERT INTO shoplists (User_Id) VALUES (@UserId)";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    { // lie les @ a une string
                        command.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Its work! Post effectué! ";
                        }
                        else
                        {
                            return "Post failled, no row creat";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // gestion de l'erreur
                return $"Error during post: {ex.Message}";
            }
        }


        private IEnumerable<Shoplists> HttpGetAllShoplists()
        {

        List<Shoplists> shoplists = new List<Shoplists>(); //cree une liste vide

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM shoplists"; // recupère tt les products

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shoplists shoplist = new Shoplists // retourne en object les données de ma base SQL
                            {
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                User_Id = Convert.ToInt32(reader["User_Id"])
                            };
                            shoplists.Add(shoplist);
                        }
                    }
                }
            }
            return shoplists;
        }


        private string HttpPutShoplistById(int id, int userId)
        {
            //Put = Update, ou crée si existe pas

            try
            {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "UPDATE shoplists SET User_Id = @UserId WHERE Shoplist_Id = @ShoplistId"; // ma query SQL

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@ShoplistId", id);

                    // permet d'envoyé des données dans la query par un @ en C#

                   int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)

                        {
                            return "Its work! Product mis a jour! ";
                        }
                        else
                        {
                            //cree un product sur le haut de la liste si aucun id atribué
                            HttpPostNewShoplist(userId);
                            return "This Id is empty, New Product created";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // gestion de l'erreur
                return $"Error during PUT: {ex.Message}";
            }
        }


        private Shoplists HttpGetShoplistById(int id)
        {
            
        Shoplists shoplist = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM shoplists WHERE Shoplist_Id = @ShoplistId"; // ma query SQL

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    command.Parameters.AddWithValue("@ShoplistId", id); 
                    // permet d'envoyé des données dans la query par un @ en C#

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shoplist = new Shoplists
                            {
                                Shoplist_Id = Convert.ToInt32(reader["Shoplist_Id"]),
                                User_Id = Convert.ToInt32(reader["User_Id"])
                            };
                        }
                    }
                }
            }

            return shoplist;
        }


        private string HttpDelShoplistById(int id)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "DELETE FROM shoplists WHERE Shoplist_Id = @ShoplistId"; // ma query SQL

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@ShoplistId", id); 
                        // permet d'envoyé des données dans la query par un @ en C#

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Its work! Shoplist supprimer! ";
                        }
                        else
                        {
                            return "Invalid id, Error =  " + (int)HttpStatusCode.BadRequest;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // gestion de l'erreur
                return $"Error during DEL: {ex.Message}";
            }
        }

    }

}
