if (Info[0] == undefined) {
	container = document.getElementById("containerMain");
	container.innerHTML = Page404;
}else{
	Info = Info[0];

	info = document.getElementById("info-titre");
	info.innerHTML += Info.Titre;
	info = document.getElementById("info-type");
	info.innerHTML += Info.libelle;
	info = document.getElementById("info-desc");
	info.innerHTML += Info.Contenue;
}