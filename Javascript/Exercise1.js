const TAX_RATE = 0.05;
const PHONE_PRICE = 25;
const ACCESSORY_PRICE = 4;
const SPENDING_THRESHOLD = 250;
var bankBalance = 300;
var totalPhoneCost = 0;

function calculatedPurchase(phoneCost) {
	phoneCost = phoneCost * TAX_RATE;
	return phoneCost;
}

function formatPrice(price) {
	return "$" + price.toFixed(2);
}

function purchase() {
	while(totalPhoneCost < bankBalance ) {
		totalPhoneCost  = totalPhoneCost + PHONE_PRICE;
		if(totalPhoneCost <= SPENDING_THRESHOLD)
		{
			totalPhoneCost = totalPhoneCost + ACCESSORY_PRICE;
		}	
	}
	calculatedPurchase(totalPhoneCost);
	console.log("Total Phone Cost : " + formatPrice(totalPhoneCost));
	bankBalance = bankBalance - totalPhoneCost;
	console.log("Bank balance : " + formatPrice(bankBalance));
}

purchase();