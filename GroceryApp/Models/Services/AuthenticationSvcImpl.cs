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
    public class AuthenticationSvcImpl:IAuthenticationSvc
    {
        Socket socket = null;
        IPEndPoint ipEndPoint =null;
        BinaryFormatter formatter = new BinaryFormatter();
        BinaryReader reader = null;
        NetworkStream stream = null;
        BinaryWriter writer = null;

       
        
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