const fs = require('fs')
const path = require('path')

function readFiles(directory,extension,callback){
	fs.readdir(directory, function(err,list){
		if(err){
			return callback(err,null)
		}else{
		let filteredFiles = new Array()
		list.forEach(function(file){
			if(path.extname(file) == '.'+extension){
				filteredFiles.push(file)
			}
		})
		return callback(null,filteredFiles)
		}
	})
}
module.exports = readFiles