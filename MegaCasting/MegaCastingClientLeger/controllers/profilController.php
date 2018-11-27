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

//affiche le template d'authentification
$page = functions::authTemplate($page);

// récupere toute les offres de la bdd
$profil = requeteSql::getProfil();
// transfert les offres du php au js
$page .= functions::SendVar('Profil', $profil);

// on affiche la vue
echo $page;

 ?>