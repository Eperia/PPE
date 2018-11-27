<?php 
session_start();
include '../services/requeteSql.php';
include '../services/function.php';

if (isset($_GET["auth-name"])){
	$email = htmlentities($_GET["auth-name"]);
	$password = htmlentities($_GET["auth-pass"]);
	requeteSql::connexion($email, $password);
	header("Location: boutiqueController.php");	
}

$scripts = "";

// recupere le contenue de la vue
$page = file_get_contents('../views/boutique.php');

$header = file_get_contents('../template/header.html');
$page = str_replace("||HEADER||", $header, $page);

$footer = file_get_contents('../template/footer.html');
$page = str_replace("||FOOTER||", $footer, $page);

//affiche le template d'authentification
$page = functions::authTemplate($page);

// récupere toute les offres de la bdd
$listPacks = requeteSql::getAllPacks();
// transfert les offres du php au js
$scripts .= functions::SendVar('Packs', $listPacks);

$page = str_replace("||SCRIPTS||", $scripts, $page);

// on affiche la vue
echo $page;

 ?>