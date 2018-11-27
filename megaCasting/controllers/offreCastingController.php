<?php 
session_start();
include '../services/requeteSql.php';
include '../services/function.php';

if (isset($_GET["auth-name"])){
	$email = htmlentities($_GET["auth-name"]);
	$password = htmlentities($_GET["auth-pass"]);
	requeteSql::connexion($email, $password);
	$id = htmlentities($_GET["id"]);
	header("Location: offreCastingController.php?id=$id");	
}

// recupere le contenue de la vue
$page = file_get_contents('../views/offreCasting.php');

$header = file_get_contents('../template/header.html');
$page = str_replace("||HEADER||", $header, $page);

$footer = file_get_contents('../template/footer.html');
$page = str_replace("||FOOTER||", $footer, $page);

//affiche le template d'authentification
$page = functions::authTemplate($page);

$scripts = "";

// récupere toute les offres de la bdd
$Offre = requeteSql::getSearchOffres($_GET["id"]);
// transfert les offres du php au js
$scripts .= functions::SendVar('Offre', $Offre);

$Page404 = file_get_contents('../template/error404.html');
$scripts .= functions::SendVar('Page404', $Page404);

$page = str_replace("||SCRIPTS||", $scripts, $page);

// on affiche la vue
echo $page;

 ?>