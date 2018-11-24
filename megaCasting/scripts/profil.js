function showListOffres(self, offres){
// pour chaque offre on génère une div que l'on rajoute sur la page
for (var i = 0; i < offres.length; i++) {
	self.appendChild(new OffreContainer(offres[i]).container);
}
}
// forme de la div ajouter a la page
function OffreContainer(offre){
	var div = document.createElement('div');
	div.className = 'offre-div';

	var titre = document.createElement('span');
	titre.className = 'offre-titre';
	titre.innerHTML = offre.Titre;

	var date = document.createElement('span');
	date.className = 'offre-date';
	date.innerHTML = "Date de début :" + dateFormat(offre["dt-demande"].date, "dd mmmm yyyy");

	var description = document.createElement('div');
	description.className = 'offre-desc';
	description.innerHTML = "<div>Description: </div>" + offre.desc + "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

	var clearboth = document.createElement('div');
	clearboth.className = 'clearboth';

	div.appendChild(titre);
	div.appendChild(date);
	div.appendChild(description);
	div.appendChild(clearboth);

	this.__defineGetter__('container', () => div);
}


if (Profil == null) {
	container = document.getElementById("containerMain");
	container.innerHTML = Page404;
}

info = document.getElementById("profil-img");
info.innerHTML += "<i class='fas fa-user-alt'>";
info = document.getElementById("profil-nom");
info.innerHTML += Profil.Nom;

info = document.getElementById("profil-add");
info.innerHTML += Profil.Adresse;
info = document.getElementById("profil-tel");
info.innerHTML += (Profil.Telephone != null)?Profil.Telephone : "Non renseigner";
info = document.getElementById("profil-email");
info.innerHTML += (Profil.Email != null)?Profil.Email : "Non renseigner";
info = document.getElementById("profil-fax");
info.innerHTML += (Profil.Fax != null)?Profil.Fax : "Non renseigner";
info = document.getElementById("profil-url");
info.innerHTML += (Profil.Url != null)?"<a href='" + Profil.Url + "'>"+ Profil.Url + "</a>" : "Non renseigner";


var container = document.getElementById("ContainerOffres");
if (Offres.length == 0) {
	container.innerHTML = "<div class='div-empty-offres'>Ce professionnel ne recherche pas de candidat actuellement</div>"
}
showListOffres(container, Offres);