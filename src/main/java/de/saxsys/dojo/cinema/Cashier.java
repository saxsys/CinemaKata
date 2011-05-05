package de.saxsys.dojo.cinema;

/**
 * Die Klasse Cashier bildet eine Kinokasse ab, an der man der folgende
 * Reihenfolge bezahlt:
 * <ol>
 * <li>Film auswählen, {@link #startPurchase(String title)}</li>
 * <li>Alle Tickets mit Altersangabe wählen, {@link #addTicket(int age)}</li>
 * <li>Preis berechnen lassen, {@link #finishPurchase()}</li>
 * </ol>
 */
public class Cashier {

	private int totalPrice;
	private String title;
	private int ticketCount;

	void startPurchase(String title) {
		this.title = title;
	}

	public void addTicket(int age) {
		ticketCount++;

		if (age > 14) {
			totalPrice += 800;
		} else {
			totalPrice += 550;
		}
	}

	public int finishPurchase() {
		int price = totalPrice;
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
