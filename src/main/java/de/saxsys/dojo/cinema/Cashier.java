package de.saxsys.dojo.cinema;

/**
 * Die Klasse Cashier bildet eine Kinokasse ab, an der man in der folgenden
 * Reihenfolge bezahlt:
 * <ol>
 * <li>Film auswählen, {@link #startPurchase(String title)}</li>
 * <li>Alle Tickets mit Altersangabe wählen, {@link #addTicket(int age)}</li>
 * <li>Preis berechnen lassen, {@link #finishPurchase()}</li>
 * </ol>
 */
public class Cashier {

	private int totalPrice = 0;
	private String title;
	private int ticketCount = 0;

	void startPurchase(String title) {
		this.title = title;
	}

	public void addTicket(int age) {
		ticketCount++;

		// Älter als 14 bedeutet Erwachsener und muss einen höheren Preis
		// bezahlen
		if (age > 14) {
			totalPrice += 800;
		} else {
			totalPrice += 550;
		}
	}

	/**
	 * @return Gesamtpreis (in Cent)
	 */
	public int finishPurchase() {

		// TODO Refactoring, weil zu viele Preis-Variablen verwirren
		int price = totalPrice;

		// Gruppenpreis (600) vergeben
		if (ticketCount >= 10) {
			int discountedPrice = ticketCount * 600;

			if (discountedPrice < totalPrice) {
				price = discountedPrice;
			}
		}
		if (isOvertime()) {
			price += 100 * ticketCount;
		}
		return price;
	}

	private boolean isOvertime() {
		return title.equals("Titanic");
	}
}
