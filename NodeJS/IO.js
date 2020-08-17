//--> Read new lines from file synchronously
var fs = require('fs')

var newLines = fs.readFileSync(process.argv[2], 'utf8').split('\n').length
console.log(newLines - 1)