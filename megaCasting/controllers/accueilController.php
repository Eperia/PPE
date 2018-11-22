<?php 
session_start();
include '../services/requeteSql.php';
include '../services/function.php';

if (isset($_GET["auth-name"])){
	$email = htmlentities($_GET["auth-name"]);
	$password = htmlentities($_GET["auth-pass"]);
	requeteSql::connexion($email, $password);
	header("Location: accueilController.php");	
}

$scripts = "";

// recupere le contenue de la vue
$page = file_get_contents('../views/accueil.php');

//affiche le template d'authentification
$page = functions::authTemplate($page);

// récupere toute les offres de la bdd
$listOffres = requeteSql::getAlloffres();
// transfert les offres du php au js
$scripts .= functions::SendVar('Offres', $listOffres);

$listTypesEmplois = requeteSql::getAllTypeEmplois();
// transfert les types d'emplois du php au js
$scripts .= functions::SendVar('TypesContrats', $listTypesEmplois);

$listTypesMetiers = requeteSql::getAllTypesMetiers();
// transfert les types d'emplois du php au js
$scripts .= functions::SendVar('TypesMetiers', $listTypesMetiers);

$page = str_replace("||SCRIPTS||", $scripts, $page);

// on affiche la vue
echo $page;

 ?>