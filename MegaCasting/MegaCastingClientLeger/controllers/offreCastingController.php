<?php 
session_start();
include '../services/requeteSql.php';
include '../services/function.php';

//if (isset($_GET["connexion"])) requeteSql::connexion(htmlentities($GET['email']), htmlentities($_GET('password')));

// recupere le contenue de la vue
$page = file_get_contents('../views/offreCasting.php');

//affiche le template d'authentification
$page = functions::authTemplate($page);

// récupere toute les offres de la bdd
$Offre = requeteSql::getSearchArticles($_GET["idOfrre"]);
// transfert les offres du php au js
$page .= functions::SendVar('Offre', $Offre);

// on affiche la vue
echo $page;

 ?>