function getElementsByAttribute(name, val) {
	return document.querySelectorAll(`[${name}="${val}"]`);
}

function listElementForm(){
	var list = ["input", "select", "textarea"] 
	return list;
} 

function getErrorForm(divFieldForm){
	var errorExist;
	var listError = getElementsByAttribute("error", "empty");
	for (var i = 0; i < listError.length; i++) {
		if (divFieldForm == listError[i].parentNode) errorExist = listError[i];
	}
	return errorExist;
}

function gestionErrorForm(){

	var forms = getElementsByAttribute("divType", "form");
	for (var x = 0; x < forms.length; x++) {
		var formAct = forms[x];
		formAct.setAttribute("idForm", x);
		var listElement = listElementForm();
		for (var i = 0; i < listElement.length; i++) {
			var inputs = formAct.getElementsByTagName(listElement[i]);
			if (listElement[i] != "textarea") setEnterFunct(inputs);

			for (var y = 0; y < inputs.length; y++) {
				var inputAct = inputs[y];
				setOldValue(inputAct.getAttribute("name"));
				if (inputAct.getAttribute("type") == "submit") {
					var value = inputAct.getAttribute("text");
					inputAct.setAttribute("type", "button");
					inputAct.setAttribute("idForm", x);
					inputAct.setAttribute("id", "submit" + x);
					inputAct.value = value;
					inputAct.addEventListener("click", function(event){
						VerifFormIsRight(event.target);
					});
				}
			}
		}
	}

}

function VerifFormIsRight(target){
	var idForm = target.getAttribute("idForm");
	console.log(idForm);
	var formAct = getElementsByAttribute("idForm", idForm)[0];

	var action = formAct.getAttribute("action");
	if (action.match(`([a-zA-Z0-9]*)=([a-zA-Z0-9]*)`)) {
		link = action + "&";
	}else{
		link = action + "?";
	}
	var formValide = true;
	
	var listElement = listElementForm();
	for (var i = 0; i < listElement.length; i++) {

		var inputs = formAct.getElementsByTagName(listElement[i]);
		for (var y = 0; y < inputs.length; y++) {
			var inputAct = inputs[y];
			var name = inputAct.name;
			var value = inputAct.value;
			if (inputAct.getAttribute("id") != "submit" + idForm){ 
				if (inputAct.getAttribute("type") == 'checkbox')value = inputAct.checked;
				
				if (inputAct.hasAttribute("required")){

					if (value == "" || value == null) {
						if (!getErrorForm(inputAct.parentNode)) {
							var error = document.createElement("span");
							error.setAttribute("error", "empty");
							error.className += "error";
							error.innerHTML = "Champ Obligatoire";
							inputAct.parentNode.appendChild(error);
						}
						formValide = false;
					}else{
						if (error = getErrorForm(inputAct.parentNode)) {
							inputAct.parentNode.removeChild(error);
						}
					}
				}
				link += name + "=" + value + "&";
			}
		}
	}
	link = link.substring(0, link.length -1);
	if (formValide) document.location.href = link;
}

function setEnterFunct(listInputs){
	for (var i = 0; i < listInputs.length; i++) {
		listInputs[i].addEventListener('keypress', function (event) {
			if (event.key === 'Enter') {
				var formAct = event.target;
				while(formAct.getAttribute("idForm") == null){
					formAct = formAct.parentNode;
				}
				VerifFormIsRight(formAct);
			}
		});
	}
}

function setOldValue(name){
	if (value = document.location.href.match(`${name}=([a-zA-Z0-9]*)`)) {
		value = value[1];
		var element = getElementsByAttribute("name", name);
		if (element[0].getAttribute("type") == "password"){}
		else if(element[0].tagName == "TEXTAREA"){
				element[0].innerHTML = value;
		}else{
			element[0].setAttribute("value", value);
		}
	}
}

gestionErrorForm();