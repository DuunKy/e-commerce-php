using Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;


class SimpleHttpServer
{
    private HttpListener listener;
    private List<Users> user;

    public SimpleHttpServer(string prefixes)
    {
        
        listener = new HttpListener();
        // Initialize the listener

        listener.Prefixes.Add(prefixes);
        //ecoute les requestes sur cette URL
        // prefixes="http://localhost:8080/"

    }

    // FIXME: Ajouter l'asyncrone https://learn.microsoft.com/fr-fr/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public void Start()
    {
        listener.Start();
        Console.WriteLine("Server started. Listening for requests...");
        Console.WriteLine("http://0.0.0.0:8080/");

        while (true)
        {
            try
            {
                HttpListenerContext context = listener.GetContext();

                //la méthode GetContext() est utilisée pour écouter et attendre une nouvelle requête HTTP entrante,
                // cette methode return un object HttpListenerContext
                // HttpListenerContext possède les info HttpListenerRequest et HttpListenerResponse 

                ProcessRequest(context);

                //ici le traitement de la requete a lieu
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling request: {ex.Message}");
            }
        }
    }

    private void ProcessRequest(HttpListenerContext context)
    {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        // la requete et la reponse, soit les deux elements d'un listener http

        string responseString = "";

        if (request.HttpMethod == "GET" && request.Url.PathAndQuery == "/api/status")
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; //cette ligne rend le json html jolie
            responseString = "The api is running!  " + (int)HttpStatusCode.OK ;
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/users")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.UsersController().ProcessRequest(request);
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/products")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.ProductsController().ProcessRequest(request);
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/shoplists")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.ShoplistsController().ProcessRequest(request);
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/carts")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.CartsController().ProcessRequest(request);
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/commands")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.CommandsController().ProcessRequest(request);
        }

        else if (request.Url.AbsolutePath.StartsWith("/api/invoices")) // tchek si l'url commence avec api/users
        {
            responseString = new Controllers.InvoicesController().ProcessRequest(request);
        }

        else
        {
            responseString = "Invalid endpoint, Error =  " + (int)HttpStatusCode.NotFound;
            response.StatusCode = (int)HttpStatusCode.NotFound;
        }

        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        using (Stream output = response.OutputStream)
        {
            output.Write(buffer, 0, buffer.Length);
        }
    }
}

class Program
{
    static void Main()
    {
        string prefixes = "http://*:8080/";
        SimpleHttpServer server = new SimpleHttpServer(prefixes); //demarre le serveur web en localhost:8080

        server.Start();
    }
}
