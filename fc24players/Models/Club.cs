﻿namespace fc24players.Models;

public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? AltName { get; set; }
    public string? Code { get; set; }
    public string? Stadium { get; set; }
    public string? Location { get; set; }
    public int? YearFounded { get; set; }
    public Manager? Manager { get; set; }
    public ICollection<Card> Cards { get; set; }
}