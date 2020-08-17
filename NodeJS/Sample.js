//--> Sum of integers
var sumTotal = 0;
var inputArray = process.argv
var inLength = process.argv.length

var sumOfNumbers = function() {
	for(var i=2;i<inLength;i++){
		sumTotal += Number(inputArray[i])
	}
}
sumOfNumbers()
console.log(sumTotal)