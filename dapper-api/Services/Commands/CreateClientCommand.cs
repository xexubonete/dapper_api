﻿using Dapper;
using dapper_api.Entities;
using dapper_api.Interfaces;
using MediatR;

namespace dapper_api.Services.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        public int Id;
        public string? Name;
        public string? Surname;
        public CreateClientCommand(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
        }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
        {
            private readonly IApiDbContext _context;
            public CreateClientCommandHandler(IApiDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var connection = _context.CreateConnection();
                var client = new Client
                {
                    Id = request.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                };
                string command = $"INSERT INTO [Client] ([Id], [Name], [Surname]) VALUES ({request.Id}, \'{request.Name}\', \'{request.Surname}\');";

                await connection.QueryAsync(command);

                return client;
            }
        }
    }
}
