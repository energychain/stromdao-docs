var fs=require("fs");
var StromDAOBO=require("stromdao-businessobject");
var showdown  = require('showdown');
var header=fs.readFileSync("header.html");
var footer=fs.readFileSync("footer.html");

var node = new StromDAOBO.Node({external_id:"doc",testMode:true});



args = f => f.toString ().replace (/[\r\n\s]+/g, ' ').
              match (/(?:function\s*\w*)?\s*(?:\((.*?)\)|([^\s]+))/).
              slice (1,3).
              join ('').
              split (/\s*,\s*/);

var types = [];

function introspect(name,obj) {
	var html="";
	html+=header;
	html+="<h1>node."+name+"(address)</h1>";
	
	if(fs.existsSync("md/"+name+".md"))  {
			converter = new showdown.Converter(),
			text      = fs.readFileSync("md/"+name+".md").toString();			
			html+= converter.makeHtml(text);		
	}
	html+="<h2>Methods</h2>"
	names=Object.getOwnPropertyNames(obj);
	for(var i=0;i<names.length;i++) {	
		if((names[i]!="obj")&&(names[i]!="test")) {
			
			var x= Object.getOwnPropertyDescriptor(obj,names[i]);	
				a=args(x.value);
				var ahtml="";
				var argumentlist="";
				ahtml+="<strong>Arguments</strong><ul>";
				for(var j=0;j<a.length;j++) {
						if(a[j].length>0) {
							ahtml+="<li>";
							if(a[j].indexOf("address_")==0) ahtml+="address:";
							if(a[j].indexOf("uint256_")==0) ahtml+="uint256:";
							ahtml+=a[j];  
							ahtml+="&nbsp;<a href='./type_"+a[j]+".html' class='glyphicon glyphicon-info-sign'></a>";
							ahtml+="</li>";
							if(argumentlist.length>0) argumentlist+=",";
							argumentlist+=a[j];
							if(typeof types[a[j]] == "undefined") types[a[j]]=[];
							types[a[j]].push(name+"."+names[i]);
						}
				}
				ahtml+="</ul>";	
				html+="<a name='"+names[i]+"'></a>";
				html+="<h3>"+names[i]+"("+argumentlist+")</h3>";	
				if(argumentlist.length>0) {
					html+=ahtml;
				}
				
		}
	}		
	html+=footer;
	fs.writeFileSync(name+".html",html);	
}

function saveTypes() {

for (var k in types){
    if (types.hasOwnProperty(k)) {
		var html=header;
		html+="<h1>Type:"+k+"</h1>";
		
		if(fs.existsSync("md/"+k+".md"))  {
			converter = new showdown.Converter(),
			text      = fs.readFileSync("md/"+k+".md").toString();			
			html+= converter.makeHtml(text);		
		}
	
		html+="<h3>Used by</h3><ul>";
		for(i=0;i<types[k].length;i++) {
			var ro=types[k][i].split(".");
			var tclass=ro[0];
			var tmethod=ro[1];
			html+="<li><a href='./"+tclass+".html#"+tmethod+"'>"+types[k][i]+"</a></li>";
		}
		html+="</ul>";
		html+=footer;
         //alert("Key is " + k + ", value is" + types[k]);
         fs.writeFileSync("type_"+k+".html",html);
    }
}	
	
}
function introobject(i,node) {
	var names=Object.getOwnPropertyNames(node);
	i++;	
	
	if(i>=names.length)  {
		saveTypes();
	}
	if(names[i].indexOf("_")!=0) {
		try{
		console.log(names[i]);
		var n = names[i];
		node[names[i]].apply(this,['0x0000000000000000000000000000000000000008']).then(function(x) {
						introspect(n,x);
						introobject(i,node);
		});
		//introspect(names[i]);	
		} catch(e) {
			introobject(i,node);
		};
	} else {introobject(i,node);}
}
introobject(-1,node);

