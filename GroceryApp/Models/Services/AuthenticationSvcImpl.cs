using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GroceryApp.Models.Services.Exceptions;

namespace GroceryApp.Models.Services
{
   // client socket implementation
    public class AuthenticationSvcImpl:IAuthenticationSvc
    {
        Socket socket = null;//socket object
        IPEndPoint ipEndPoint =null;//end point object
        BinaryFormatter formatter = new BinaryFormatter(); //formatter
        BinaryReader reader = null; //reader
        NetworkStream stream = null; //network stream
        BinaryWriter writer = null; //binary writer

       
        //method for connecting to server
        private void ConnectToServer()
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                socket.Connect(ipEndPoint);
                stream = new NetworkStream(socket);
                reader = new BinaryReader(stream);
                writer = new BinaryWriter(stream);
               
               
            }
            catch (Exception ex)
            {

                throw new AuthenticationException(ex.ToString());

            }
          
        }

       
        //send credentials across to server
        public Boolean SendCredentials(string username, string password)
        {
            ConnectToServer();

          //  if (socket.isConnected() == false) connectToServer();


            try
            {

                writer.Write(username+"\t"+password);

                Boolean valid = reader.ReadBoolean();               

                if (valid == true)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {                
                throw new AuthenticationException(ex.ToString());
            }           

            return false;

        }

        //close connection
         public void closeClientConnection() 
         {
       
         try
         {
         if (writer != null) writer.Close(); // close output stream
         if(reader!=null)  reader.Close(); // close input stream       
         if(socket!=null) socket.Close(); // close socket         
        
         }
         catch(IOException e)
        {
            throw new AuthenticationException("Error Closing Connection " + e);
        }
    }

    }
}