function open_token() {
	
	var tkn=$('#token_contract').val();
	$('#tkn_addr').html(tkn);
	
	node.erc20token(tkn).then(function(token) {		
			token.totalSupply().then(function(b) {
					$('#tkn_supply').html(b);
			});
			token.balanceOf(node.wallet.address).then(function(b) {
				$('#tkn_hold').html(b);
				$('#transferAmount').val(b);
				if(b>0) {
				$('#tkn_tansfer').show();
				}
			});
			$('#tkn_tbl').show();
			
	});
	$('#transfer_tokens').click(function() {
		$('#transfer_tokens').attr('disabled','disabled');
		node.erc20token($('#token_contract').val()).then(function(token) {	
			token.transfer($('#transferTo').val(),$('#transferAmount').val()).then(function(tx) {
				console.log(tx);
				$('#transfer_tokens').removeAttr('disabled');
				open_token();
			});
		});
	});
}

function view_token() {
	
	var tkn=$('#view_contract').val();
	$('#view_addr').html(tkn);
	
	node.erc20token(tkn).then(function(token) {		
			token.totalSupply().then(function(b) {
					$('#view_supply').html(b);
			});
			token.balanceOf($('#view_address').val()).then(function(b) {
				$('#view_hold').html(b);			
			});
			$('#view_tbl').show();
			
	});
}	
function xtoken() {
	if(node.storage.getItemSync("time_token")==null) return;
	if(node.storage.getItemSync("power_token")==null) return;
	if(node.storage.getItemSync("xtoken")==null) {
		node.xtokenfactory().then(function(xtf) {
			xtf.build().then(function(tx) {
				var xtoken=tx;									
				node.xtoken(xtoken).then(function(xt) {
					node.storage.setItemSync("xtoken",xtoken);
					xt.setRate(node.storage.getItemSync("time_token"),2).then(function(tx) {
						xt.setRate(node.storage.getItemSync("power_token"),3).then(function(tx) {
							node.storage.setItemSync("xtoken",xtoken);
							location.reload();
							//xtoken();
						}).catch(function() {location.reload();});;						
					});						
				});
			});
		});		
	} else {
		$('.xt_address').html(node.storage.getItemSync("xtoken"));	
			node.erc20token(node.storage.getItemSync("xtoken")).then(function(e20) {								
				e20.balanceOf(node.wallet.address).then(function(tx) {
						$('#xt_hold').html(tx);
				});
				e20.totalSupply().then(function(tx) {
						$('#xt_ts').html(tx);
				});
			});
			$('.issueX').removeAttr('disabled');
			$('.issueX').removeAttr('disabled');
			refreshTokenInfo();
	}	
}


function issueXtime() {
		
		if(node.storage.getItemSync("xtoken")==null) return;
		$('.issuex').attr('disabled','disabled');
		node.xtoken(node.storage.getItemSync("xtoken")).then(function(xt) {
			if($('#tt_hold').html()*1>0) {									
				xt.xchange(node.storage.getItemSync("time_token"),$('#tt_hold').html()*1).then(function(o) {
					setTimeout(issueX,1000);
				}).catch(function() {issueX});
			} else {
				if(	$('#pt_hold').html()*1>0) {
						xt.xchange(node.storage.getItemSync("power_token"),$('#pt_hold').html()*1).then(function(o) {
						location.reload();
					}).catch(function() {location.reload();});
				}				
			}
		});
}
function issueXpower() {
		if(node.storage.getItemSync("xtoken")==null) return;
		$('.issueX').attr('disabled','disabled');
		node.xtoken(node.storage.getItemSync("xtoken")).then(function(xt) {
				if(	$('#pt_hold').html()*1>0) {
						xt.xchange(node.storage.getItemSync("power_token"),$('#pt_hold').html()*1).then(function(o) {
						location.reload();
					}).catch(function() {location.reload(); });
				}							
		});
}

function dspTokens() {
	
if(node.storage.getItemSync("time_token")!=null) {
						node.erc20token(node.storage.getItemSync("time_token")).then(function(e20) {
								$('.tt_address').html(node.storage.getItemSync("time_token"));
								e20.balanceOf(node.wallet.address).then(function(tx) {
										$('#tt_hold').html(tx);
								});
								e20.totalSupply().then(function(tx) {
										$('#tt_ts').html(tx);
								});
						});
					}		
					if(node.storage.getItemSync("power_token")!=null) {
						node.erc20token(node.storage.getItemSync("power_token")).then(function(e20) {
								$('.pt_address').html(node.storage.getItemSync("power_token"));
								e20.balanceOf(node.wallet.address).then(function(tx) {
										$('#pt_hold').html(tx);
								});
								e20.totalSupply().then(function(tx) {
										$('#pt_ts').html(tx);
										$('#issueToken').removeAttr('disabled');
										if(node.storage.getItemSync("xtoken")==null) {
											$('#createX').removeAttr('disabled');
										}
								});
						});
}
						
}
function refreshTokenInfo() {
	dspTokens();
	$('#issueToken').attr('disabled','disabled');
	if(node.storage.getItemSync("mptoken")!=null) {
		$('#tt_address').html(node.storage.getItemSync("time_token"));
		$('#pt_address').html(node.storage.getItemSync("power_token"));
		$('#createToken').attr('disabled','disabled');
		node.mptoken(node.storage.getItemSync("mptoken")).then(function(mpt) {
				mpt.issue().then(function(tx) {
					dspTokens();												
				});
		});
	} else {
			createToken();
	}
}
function createToken() {
	
$('#createToken').attr('disabled','disabled');
	node.mptokenfactory().then(function(mptf) {
		mptf.build("0x0000000000000000000000000000000000000008","0xAb01e9d7625296A7758b4B86D650bD8E435DB44a").then(function(tx) {
				node.storage.setItemSync("mptoken",tx);
				node.mptoken(tx).then(function(mpt) {
						mpt.time_token().then(function(time_token) {
								node.storage.setItemSync("time_token",time_token);								
								mpt.power_token().then(function(power_token) {
									node.storage.setItemSync("power_token",power_token);
										location.reload();
										//
									});
						});
				});
		});			
	});	
}
// Retrieve Reading
function getReading() {
	node.mpr().then(function(mpr) {
		mpr.readings("0xAb01e9d7625296A7758b4B86D650bD8E435DB44a").then(function(tx) {
				$('#reading').val(tx.power.toString());								
				$('.reading').html(tx.power.toString());
				$('.readingtime').html(new Date(tx.time.toString()*1000).toLocaleString());
				if(parseInt(tx.power.toString())!=0) {
					refreshTokenInfo();
				}
		});	
	});
}

function saveReading() {
	$('#save').attr('disabled','disabled');
	node.mpr().then(function(mpr) {
		mpr.storeReading($('#reading').val()).then(function(tx) {
			$('#save').removeAttr('disabled');
			getReading();			
		});
	});
}
$.qparams = function(name){
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results==null){
       return null;
    }
    else{
       return decodeURI(results[1]) || 0;
    }
}

var extid="1234";

if($.qparams("extid")!=null) {
		extid=$.qparams("extid");
}
var node = new document.StromDAOBO.Node({external_id:extid,testMode:true,rpc:"https://stromdao.de/rpc",abilocation:"https://raw.githubusercontent.com/energychain/StromDAO-BusinessObject/master/smart_contracts"});

// Fill View (HTML) using JQuery
$('.account').html(node.wallet.address);

$('#createToken').click(function() {
	createToken();
});
$('#issueToken').click(function() {
	refreshTokenInfo();
});
$('#createX').click(function() {
	$('#createX').attr('disabled','disabled');
	xtoken();
});
$('#issueXtime').click(function() {
	issueXtime();
});
$('#issueXpower').click(function() {
	issueXpower();
});
$('#open_token').click(function() {open_token()});
$('#view_token').click(function() {view_token()});
if(node.storage.getItemSync("xtoken")!=null) {
	xtoken();
}
getReading();
$('#save').click(getReading);

