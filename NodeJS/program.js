const http = require('http')
//'http://nodejs.org/dist/index.json'
http.get(process.argv[2],function callback(response){
	response.setEncoding('utf8')
	response.on('data', function(data){
		console.log(data)
	})
}).on('error', function(err){
	console.error
	return
})