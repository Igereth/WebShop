using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Microservice
{
    public class Lager
    {
		private List<ProduktUebersicht> _produkte;

		public List<ProduktUebersicht> Produkte
		{
			get { return _produkte; }
			set { _produkte = value; }
		}

		public Lager()
		{
			Produkte = new List<ProduktUebersicht>();
		}


		public bool NeuesProduktHinzufuegen(Produkt produkt)
		{
			bool Ergebniss = true;
			ProduktUebersicht PU = new ProduktUebersicht();
			
			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt == produkt)
				{
					Ergebniss = false;
					break;
				}
			}
			
			if (Ergebniss)
			{
				PU.produkt = produkt;
				Produkte.Add(PU);
			}

			return Ergebniss;
		}

		public bool ProduktBeschreibungAktualisieren(Produkt produkt)
		{
			bool Ergebniss = false;
			ProduktUebersicht PU = new ProduktUebersicht();

			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt.ID == produkt.ID)
				{
					PU.produkt = produkt;
					Produkte[i] = PU;
					Ergebniss = true;
					break;
				}
			}

			return Ergebniss;
		}

		public bool ProduktReservieren(int ProduktId, int Anzahl)
		{
			bool Ergebniss = false;
			
			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt.ID == ProduktId)
				{
					if (Produkte[i].SollLager >= Anzahl)
					{
						ProduktUebersicht PU = Produkte[i];
						PU.SollLager -= Anzahl;
						Produkte[i] = PU;
						Ergebniss = true;
					}

					break;
				}
			}

			return Ergebniss;
		}

		public bool ProduktReservierungAufheben(int ProduktId, int Anzahl)
		{
			bool Ergebniss = false;

			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt.ID == ProduktId)
				{
					if (Produkte[i].IstLager - Produkte[i].SollLager >= Anzahl)
					{
						ProduktUebersicht PU = Produkte[i];
						PU.SollLager += Anzahl;
						Produkte[i] = PU;
						Ergebniss = true;
					}

					break;
				}
			}

			return Ergebniss;
		}

		public bool ProdukteEntfernen(int ProduktId, int Anzahl, bool HatReservierung)
		{
			bool Ergebniss = false;

			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt.ID == ProduktId)
				{
					if (Produkte[i].SollLager >= Anzahl)
					{
						ProduktUebersicht PU = Produkte[i];
						PU.IstLager -= Anzahl;
						if (!HatReservierung)
						{
							PU.SollLager -= Anzahl;

						}
						Produkte[i] = PU;
						Ergebniss = true;
					}
					
					break;
				}
			}

			return Ergebniss;
		}

		public bool ProdukteHinzufuegen(int ProduktId, int Anzahl)
		{
			bool Ergebniss = false;

			for (int i = 0; i < Produkte.Count; i++)
			{
				if (Produkte[i].produkt.ID == ProduktId)
				{
					ProduktUebersicht PU = Produkte[i];
					PU.IstLager += Anzahl;
					PU.SollLager += Anzahl;
					Produkte[i] = PU;
					Ergebniss = true;

					break;
				}
			}

			return Ergebniss;
		}
	}
}
