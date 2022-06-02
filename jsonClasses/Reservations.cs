﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;

namespace GhibliFlix
{
    internal class Reservations
    {
        internal List<Reservation> reservations { get; set; }

        internal static Reservations FetchAll()
        {

        }

        internal static List<Reservation> FetchAll(DateTime date)
        {
            return FetchAll().reservations.Where(r => r.ReservationDate == date.ToShortDateString()).ToList());
        }
        public static void Save(Reservation reservation)
        {
            Reservations reservations = FetchAll();
            reservations.reservations.Add(reservation);

            string json = JsonSerializer.Serialize(reservations);
            File.WriteAllText("json_files/reservations.json", json);
        }

    }
}
