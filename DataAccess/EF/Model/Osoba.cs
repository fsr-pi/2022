﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EF.Model
{
    public partial class Osoba
    {
        /// <summary>
        /// Identifikator osobe
        /// </summary>
        public int IdOsobe { get; set; }
        /// <summary>
        /// Prezime osobe
        /// </summary>
        public string PrezimeOsobe { get; set; }
        /// <summary>
        /// Ime osobe
        /// </summary>
        public string ImeOsobe { get; set; }

        public virtual Partner IdOsobeNavigation { get; set; }
    }
}