const mymodule = require('./filemodule')

mymodule(process.argv[2],process.argv[3],function(err,data){
	if(err){
		console.log(err)
	} else {
		let files = data
		if(files){
			files.forEach(function(file){
				console.log(file)
			})
		}
	}
})