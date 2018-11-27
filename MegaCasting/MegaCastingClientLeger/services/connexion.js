
if (document.getElementById("btn-panel-login") != undefined) {
	document.getElementById("btn-panel-login").addEventListener("click", function(){
		var backpanel = document.getElementById("back-panel-login");
		var panel = document.getElementById("panel-login");
		if (backpanel.getAttribute("display") == "none") {
			backpanel.setAttribute("display", "yes");
			panel.setAttribute("show","");
		}
	});

	document.getElementById("back-panel-login").addEventListener("click", function(event){
		var backpanel = document.getElementById("back-panel-login");
		var panel = document.getElementById("panel-login");
		if (event.target.getAttribute("id") == "back-panel-login") {
			backpanel.setAttribute("display", "none");
			panel.removeAttribute("show");
		}
	});
}

