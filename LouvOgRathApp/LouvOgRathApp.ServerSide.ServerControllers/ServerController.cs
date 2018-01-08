/**************************************************************************************************
*  Author: Mads Mikkel Rasmussen (mara@aspit.dk), github: https://github.com/Mara-AspIT/          *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository:                                     *
**************************************************************************************************/

using System;
using System.Net;
using System.Net.Sockets;
using LouvOgRathApp.ServerSide.DataAccess;
using LouvOgRathApp.Shared.Entities;
using LouvOgRathApp.Shared.TcpCommunications;

namespace LouvOgRathApp.ServerSide.ServerControllers
{
    /// <summary>Handles incoming requests from clients. Should not be visible outside this namespace.</summary>
    internal class ServerController
    {
        #region Constants
        /// <summary>The upper limit to both <see cref="recieveBuffer"/> and <see cref="sendBuffer"/>.</summary>
        const int bufferLimit = CommunicationConstants.BufferLimit;
        #endregion


        #region Fields
        /// <summary>The listener.</summary>
        protected TcpListener listener;

        /// <summary>The currently connected client.</summary>
        protected TcpClient connectedClient;

        // TODO: Add nescessary new repositories here:

        /// <summary>The bytes loaded from a client stream.</summary>
        protected byte[] recieveBuffer = new byte[bufferLimit];

        /// <summary>The bytes to transmit through the stream of the <see cref="connectedClient"/>.</summary>
        protected byte[] sendBuffer = new byte[bufferLimit];
        #endregion


        #region Constructors
        /// <summary>
        /// TODO: Create appropriate documentation.
        /// </summary>
        internal ServerController()
        {
            Console.WriteLine("Starting server...");
            try
            {
                // TODO: Replace hardcoded ip and port with config file: 
                listener = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 65432));
                // TODO: initialize new repositories here:
            }
            catch(Exception)
            {
                // TODO: Replace with CommunicationsException.
                throw;
            }
        }
        #endregion


        #region Methods
        /// <summary>Starts the internal <see cref="TcpListener"/>. Can be overridden.</summary>
        internal virtual void Run()
        {
            // Do not modify this method.
            try
            {
                listener.Start();
            }
            catch(Exception)
            {
                throw;
            }
            Console.WriteLine("Server started. Waiting for a client to connect...");
            while(true)
            {
                try
                {
                    using(connectedClient = listener.AcceptTcpClient())
                    {
                        Console.WriteLine("A client has connected.");
                        connectedClient.Client.Receive(recieveBuffer);
                        ClientRequest clientRequest = Serializer<ClientRequest>.Deserialize(recieveBuffer);
                        Array.Clear(recieveBuffer, index: 0, length: recieveBuffer.Length);
                        Process(clientRequest);
                    }
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>Processes a client request.</summary>
        /// <param name="clientRequest">The client request to process.</param>
        protected virtual void Process(ClientRequest clientRequest)
        {
            if(clientRequest is null)
            {
                throw new ArgumentNullException(nameof(clientRequest));
            }
            try
            {
                switch(clientRequest.RequestedAction)
                {
                    //TODO: Add cases as nescessary here:
                    default:
                        break;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>Responds to the <see cref="connectedClient"/> with the provided <see cref="TransmissionData"/>.</summary>
        /// <param name="transmissionData">The <see cref="TransmissionData"/> object to transmit to the <see cref="connectedClient"/> as a response.</param>
        protected virtual void RespondToClient(TransmissionData transmissionData)
        {
            // Do not modify this method.
            if(transmissionData == null)
            {
                throw new ArgumentNullException(nameof(transmissionData));
            }
            try
            {
                Array.Clear(sendBuffer, index: 0, length: sendBuffer.Length);
                sendBuffer = Serializer<TransmissionData>.Serialize(transmissionData);
                connectedClient.GetStream().Write(sendBuffer, offset: 0, size: sendBuffer.Length);
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion
    }
}