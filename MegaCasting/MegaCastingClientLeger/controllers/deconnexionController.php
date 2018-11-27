<?php 

include '../services/requeteSql.php';

requeteSql::Deconnexion();

header("Location: accueilController.php");

 ?>