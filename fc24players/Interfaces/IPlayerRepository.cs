﻿using fc24players.Helpers;
using fc24players.Models;

namespace fc24players.Interfaces;

public interface IPlayerRepository
{
    Task<ICollection<Player>> GetAll(PaginationQueryObject paginationQuery);
    Task<Player> GetByName();
}