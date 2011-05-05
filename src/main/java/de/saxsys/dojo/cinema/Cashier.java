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

	// TODO Wie wird die Variable totalPrice inititalisert (Gibt's einen
	// UnitTest?)?
	private int totalPrice;
	private String title;
	private int ticketCount;

	void startPurchase(String title) {
		this.title = title;
	}

	public void addTicket(int age) {
		ticketCount++;

		// TODO Was bedeutet das?
		if (age > 14) {
			// TODO Was ist 800?
			totalPrice += 800;
		} else {
			// TODO Was ist 550?
			totalPrice += 550;
		}
	}

	/**
	 * @return Gesamtpreis (in Cent)
	 */
	public int finishPurchase() {

		// TODO So viele Preise ?!?
		int price = totalPrice;

		// TODO Was ist 10?
		if (ticketCount >= 10) {
			// TODO Was bedeutet das?
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
