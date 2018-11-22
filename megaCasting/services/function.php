<?php 

/**
* 
*/
class functions
{

	// Envoie une variable php en json
	public static function SendVar($jsVarName, $content, $globalize = false){
		$content = functions::encodeUtf8($content);
		$result = '<script type="text/javascript">var ' . $jsVarName . ' = JSON.parse("' . str_replace(['\\', '"', '\''], ['\\\\', '\\"', "\\'"], json_encode($content)) . '");';
		if($globalize){
			$result .= 'window.' . $jsVarName . '=' . $jsVarName .';';
		}
		return $result . '</script>';
	}

	// place le template d'authentification sur la page demander
	public static function authTemplate($page){
		if (isset($_SESSION["loginId"]) && $_SESSION["loginId"] != null) {
			$templateAuth = file_get_contents("../template/authOK.html");
			$profil = requeteSql::getProfil($_SESSION["loginId"]);
			$templateAuth = str_replace("||NAME||", $profil["Nom"], $templateAuth);
		}else{
			$templateAuth = file_get_contents("../template/authWrong.html");
		}

		return str_replace("||AUTH||", $templateAuth, $page);
	}

	private static function encodeUtf8($array){
		if (gettype($array) == 'array') {
			foreach ($array as $key => $value) {
				if (gettype($value) == 'array') {
					$array[$key] = functions::encodeUtf8($value);
				}else if(gettype($value) == 'string'){
					$array[$key] = utf8_encode($value);
				}
			}
		}
		return $array;
	}

}

?>