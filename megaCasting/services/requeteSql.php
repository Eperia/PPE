<?php
/**
* 
*/
class requeteSQL
{

	public static function connexionBdd(){
		try{
			$serverName = "HP-PC"; //serverName\instanceName
			$connectionInfo = array( "Database"=>"megacasting", "UID"=>"sa", "PWD"=>"SQL2014");
			$bdd = sqlsrv_connect( $serverName, $connectionInfo);
			return $bdd;
		}
		catch (Exception $e){
			die('Erreur : ' . $e->getMessage());
		}
	}

	public static function closeBdd($bdd){
		sqlsrv_close($bdd);
	}

	public static function connexion($email, $password){
		$bdd =  requeteSQL::connexionBdd();
		$success = false;
		$sql = "select * from professionnel where Email = '$email' and mdp = '$password'";
		$stmt = sqlsrv_query( $bdd, $sql);
		$stmt = sqlsrv_fetch_array($stmt);
		if ($stmt != null) {
			$_SESSION["loginId"] = $stmt[0]["Id"];
			$success = true;
		}else{
			$success = false;
		}
		requeteSQL::closeBdd($bdd);
		return $success;
	}

	public static function Deconnexion(){
		session_start();
		session_destroy();

	}

	public static function getProfil($id = null){
		if ($id == null) $id = $_SESSION["loginId"];
		$bdd =  requeteSQL::connexionBdd();
		$sql = "select * from professionnel where Id=$id";
		$stmt = sqlsrv_query( $bdd, $sql);
		$stmt = sqlsrv_fetch_array($stmt);
		requeteSQL::closeBdd($bdd);
		return $stmt;
	}

	public static function getAlloffres(){
		$bdd =  requeteSQL::connexionBdd();
		$sql = "select * from OffreCasting inner join professionnel on OffreCasting.[Id-Professionel] = professionnel.Id";
		$stmt = sqlsrv_query( $bdd, $sql);
		$response = [];

		while (($temp = sqlsrv_fetch_array($stmt)) != null){
			array_push($response, $temp);
		}
		requeteSQL::closeBdd($bdd);
		return $response;
	}

	public static function getSearchOffres($search, $parametre = null){

	}
	/*
	public static function addOffreCasting($titre, $duree, $dt_debut_contrat, $nbPost, $localisation, $desc){

	}

	public static function addOffreCasting_TypeContrat($id_offreCasting, $id_typeContrat){

	}

	public static function addOffreCasting_Metier($id_offreCasting, $id_Metier){

	}
	*/
	public static function souscriptionPack($id_professionnel, $id_packCasting){

	}

	public static function getAllTypeEmplois(){
		$bdd =  requeteSQL::connexionBdd();
		$sql = "select * from TypeContrat";
		$stmt = sqlsrv_query( $bdd, $sql);
		$response = [];

		while (($temp = sqlsrv_fetch_array($stmt)) != null){
			array_push($response, $temp);
		}
		requeteSQL::closeBdd($bdd);
		return $response;
	}

	public static function getAllTypesMetiers(){
		$bdd =  requeteSQL::connexionBdd();
		$sql = "select * from DomaineMetier";
		$stmt = sqlsrv_query( $bdd, $sql);
		$response = [];

		while (($temp = sqlsrv_fetch_array($stmt)) != null){
			array_push($response, $temp);
		}
		requeteSQL::closeBdd($bdd);
		return $response;
	}
}

?>