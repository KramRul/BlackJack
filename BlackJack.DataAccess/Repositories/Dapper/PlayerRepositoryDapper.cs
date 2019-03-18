﻿using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Dapper
{
    public class PlayerRepositoryDapper : BaseRepositoryDapper<Player>, IPlayerRepository
    {
        public PlayerRepositoryDapper(IConfiguration config) : base(config)
        {
        }

        public new async Task<List<Player>> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM AspNetUsers b";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery);
                return result.ToList();
            }
        }

        public new async Task<Player> Get(Guid id)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT TOP(1) * " +
                    "FROM AspNetUsers e " +
                    "WHERE (e.Id = @id)";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery, new { id });
                return result.FirstOrDefault();
            }
        }

        public async Task<Player> GetByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT TOP(1) * " +
                    "FROM AspNetUsers e " +
                    "WHERE (e.UserName = @name)";
                conn.Open();
                var result = await conn.QueryAsync<Player>(sQuery, new { name });
                return result.FirstOrDefault();
            }
        }

        public async Task Delete(Guid id)
        {
            await Delete(new Player() { Id = id.ToString() });
        }
    }
}
