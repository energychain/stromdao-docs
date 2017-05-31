function updateUI() {
	var provider = new ethers.providers.JsonRpcProvider( "http://app.stromdao.de:8081/rpc");
	provider.getBlockNumber().then(function(o) {
		$('#block_nr').html(o);
	});
}

setInterval(function()  { updateUI();},5000);
