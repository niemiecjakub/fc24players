﻿using fc24players.Data;
using fc24players.Interfaces;
using fc24players.Models;
using Microsoft.EntityFrameworkCore;

namespace fc24players.Repository;

public class ClubRepository(ApplicationDbContext context) : IClubRepository
{
    public async Task<ICollection<Club>> GetAll()
    {
        return await context.Club.ToListAsync();
    }
}