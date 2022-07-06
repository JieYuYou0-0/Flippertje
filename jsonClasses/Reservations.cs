using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

public class Reservations
{
    public List<Reservation> reservations { get; set; }

    public static Reservations FetchAll()
    {
        string json = File.ReadAllText("jsonFiles/reservations.json");
        return JsonSerializer.Deserialize<Reservations>(json);
    }

    public static List<Reservation> FetchAll(DateTime date)
    {
        return FetchAll().reservations.Where(r => r.ReservationDate == date.ToShortDateString()).ToList();
    }

    public static void Save(Reservation reservation)
    {
        Reservations reservations = FetchAll();
        reservations.reservations.Add(reservation);

        string json = JsonSerializer.Serialize(reservations);
        File.WriteAllText("jsonFiles/reservations.json", json);
    }
}

public class Reservation
{
    public string ReservationId { get; set; }
    public bool Cancelled { get; set; }
    public string HostId { get; set; }
    public string DateOfCreation { get; set; }
    public string ReservationDate { get; set; }
    public int SeatNumber { get; set; }
    public List<Guest> Guests { get; set; }
    public double TotalCost { get; set; }
}

public class Guest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string movieChoice { get; set; }
}