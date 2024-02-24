
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
    public class InvoicesController
    {
        private string connectionString = "Server=172.16.238.10;User ID=root;Password=root;Database=dunkyandfilscorporation";
        // mes identifiants pour me connect a mon mysql workbench

// TODO: 
// gener mieux la connection sql = 1 connection


       public string ProcessRequest(HttpListenerRequest request)
        {
            string responseString = "";

            // GET
            if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/invoices")
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                responseString = JsonSerializer.Serialize(HttpGetAllInvoices(), options);
            }
            else if (request.HttpMethod == "GET" && request.Url.PathAndQuery.StartsWith("/api/invoices"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpGetInvoiceById(id), options);
                    if (responseString == "null")
                    {
                        responseString = "Invalid id, Error =  " + (int)HttpStatusCode.BadRequest;
                    }
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/invoices/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an id, please enter a valid id";
                }
            }

            // POST
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery == "/api/invoices")
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestBody = reader.ReadToEnd();
                    var data = JsonSerializer.Deserialize<Invoices>(requestBody);

                    int commandId = data.Command_Id;
                    string invoiceDate = data.Invoice_Date;

                    responseString = HttpPostNewInvoice(commandId, invoiceDate);
                }
            }
            else if (request.HttpMethod == "POST" && request.Url.PathAndQuery.StartsWith("/api/invoices"))
            {
                responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
            }

            // PUT
            // Pas de PUT pour les factures

            // DELETE
            else if (request.HttpMethod == "DELETE" && request.Url.PathAndQuery.StartsWith("/api/invoices/"))
            {
                string[] strings = request.Url.PathAndQuery.Split('/');
                string[] parts = strings;
                if (parts.Length == 4 && int.TryParse(parts[3], out int id))
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    responseString = JsonSerializer.Serialize(HttpDelInvoiceById(id), options);
                }
                else if (parts.Length > 4)
                {
                    responseString = "bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else if (request.Url.PathAndQuery == "/api/invoices/")
                {
                    responseString = "enter an id please, bad endpoint, Error =  " + (int)HttpStatusCode.BadRequest;
                }
                else
                {
                    responseString = "not an Id, Error =  " + (int)HttpStatusCode.BadRequest;
                }
            }

            // HTTP PATCH
            // Pas de PATCH pour les factures

            // Final return
            return responseString;
        }

        private string HttpPostNewInvoice(int commandId, string invoiceDate)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "INSERT INTO invoices (Command_Id, Invoice_Date) " +
                                        "VALUES (@CommandId, @InvoiceDate)";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@CommandId", commandId);
                        command.Parameters.AddWithValue("@InvoiceDate", invoiceDate);

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

        private IEnumerable<Invoices> HttpGetAllInvoices()
        {
            List<Invoices> invoices = new List<Invoices>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM invoices";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Invoices invoice = new Invoices
                            {
                                Invoices_Id = Convert.ToInt32(reader["Invoices_Id"]),
                                Command_Id = Convert.ToInt32(reader["Command_Id"]),
                                Invoice_Date = Convert.ToString(reader["Invoice_Date"])
                            };
                            invoices.Add(invoice);
                        }
                    }
                }
            }
            return invoices;
        }

        private Invoices HttpGetInvoiceById(int id)
        {
            Invoices invoice = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string SqlRequest = "SELECT * FROM invoices WHERE Invoices_Id = @InvoicesId";

                using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                {
                    command.Parameters.AddWithValue("@InvoicesId", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoice = new Invoices
                            {
                                Invoices_Id = Convert.ToInt32(reader["Invoices_Id"]),
                                Command_Id = Convert.ToInt32(reader["Command_Id"]),
                                Invoice_Date = Convert.ToString(reader["Invoice_Date"])
                            };
                        }
                    }
                }
            }

            return invoice;
        }

        private string HttpDelInvoiceById(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string SqlRequest = "DELETE FROM invoices WHERE Invoices_Id = @InvoicesId";

                    using (MySqlCommand command = new MySqlCommand(SqlRequest, connection))
                    {
                        command.Parameters.AddWithValue("@InvoicesId", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return "Delete success! Invoice supprimée!";
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
