using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

internal class Reservations
{
    internal List<Reservation> reservations { get; set; }

    internal static Reservations FetchAll()
    {
        string json = File.ReadAllText("json_files/reservations.json");
        return JsonSerializer.Deserialize<Reservations>(json);
    }

    internal static List<Reservation> FetchAll(DateTime date)
    {
        return FetchAll().reservations.Where(r => r.ReservationDate == date.ToShortDateString()).ToList();
    }

    internal static void Save(Reservation reservation)
    {
        Reservations reservations = FetchAll();
        reservations.reservations.Add(reservation);

        string json = JsonSerializer.Serialize(reservations);
        File.WriteAllText("json_files/reservations.json", json);
    }
}

internal class Reservation
{
    internal string ReservationId { get; set; }
    internal bool Cancelled { get; set; }
    internal string DateOfCreation { get; set; }
    internal string ReservationDate { get; set; }
    internal int SeatNumber { get; set; }
}
internal class Guest
{
    internal string Name { get; set; }
    internal string Email { get; set; }
    internal string MovieChoice { get; set; }
}