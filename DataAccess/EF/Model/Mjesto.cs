﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EF.Model
{
    public partial class Mjesto
    {
        public Mjesto()
        {
            PartnerIdMjestaIsporukeNavigation = new HashSet<Partner>();
            PartnerIdMjestaPartneraNavigation = new HashSet<Partner>();
        }

        /// <summary>
        /// Identifikator mjesta
        /// </summary>
        public int IdMjesta { get; set; }
        /// <summary>
        /// Oznaka države
        /// </summary>
        public string OznDrzave { get; set; }
        /// <summary>
        /// Naziv mjesta
        /// </summary>
        public string NazMjesta { get; set; }
        /// <summary>
        /// Poštanski broj mjesta
        /// </summary>
        public int PostBrMjesta { get; set; }
        /// <summary>
        /// Naziv dostavne pošte
        /// </summary>
        public string PostNazMjesta { get; set; }

        public virtual Drzava OznDrzaveNavigation { get; set; }
        public virtual ICollection<Partner> PartnerIdMjestaIsporukeNavigation { get; set; }
        public virtual ICollection<Partner> PartnerIdMjestaPartneraNavigation { get; set; }
    }
}