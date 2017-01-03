var express = require('express');
var app = express();


//SETUP SERVER
var server = require('http').createServer(app);
var io = require('socket.io').listen(server);


var client = [];

io.on("connection", function(socket){

	var currentUser;
	socket.on("USER_CONNECT", function () {
		console.log("User CONNECTED");
		for(var i = 0; i < client.length; i++)
		{
			socket.emit("USER_CONNECTED", {name:client[i].name, position:clients[i].position});
		}
		console.log("User name " + clients[i].name + " is connected");
	});



	socket.on("PLAY", function(data){

		currentUser = {
			name:date.name,
			position:data.position
		}

		clients.push(currentUser);
		socket.emit("PLAY", currentUser)
		socket.broadcast.emit("USER_CONNECTED", currentUser);

	});


	socket.on("MOVE", function(data){
		currentUser.position = data.position;
		socket.emit("MOVE", currentUser);
		console.log(currentUser.name + "move to: " + currentUser.position);
	});

	socket.on("disconnect", function(){
		socket.broadcast.emit("USER_DISCONNECTED", currentUser); 
		for (var i = 0; i < clients.length; i++)
		{
			if (clients[i].name === currentUser.name)
			{
				console.log("User " + clients[i].name + " disconnected");
				clients.splice(i, 1);
			}
		}

	});


});

//SETUP PORT
app.set('port', process.env.PORT || 3000);

server.listen(app.get('port'), function(){
	console.log("SERVEUR IS RUNNING");	
});