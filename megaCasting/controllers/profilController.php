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

// recupere le contenue de la vue
$page = file_get_contents('../views/profil.php');

$header = file_get_contents('../template/header.html');
$page = str_replace("||HEADER||", $header, $page);

//affiche le template d'authentification
$page = functions::authTemplate($page);

$scripts = "";

if (isset($_GET["id"])) {
	$id = $_GET["id"];
}else{
	$id = $_SESSION["loginId"];
}
$profil = requeteSql::getProfil($id);
// transfert le profil du php au js
$scripts .= functions::SendVar('Profil', $profil);

// récupere toute les offres de la bdd
$listOffres = requeteSql::getOffresPro($id);
// transfert les offres du php au js
$scripts .= functions::SendVar('Offres', $listOffres);

$Page404 = file_get_contents('../template/error404.html');
$scripts .= functions::SendVar('Page404', $Page404);

$page = str_replace("||SCRIPTS||", $scripts, $page);

// on affiche la vue
echo $page;

 ?>