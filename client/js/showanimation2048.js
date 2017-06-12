
function showNumberWithAnimation(randomX,randomY,randomNumber){
	var numberCell = $("#number-cell-"+randomX+"-"+randomY);

	numberCell.css("background-color",getNumberCellBgColor(board[randomX][randomY]));
	numberCell.css("color",getNumberCellFontColor(board[randomX][randomY]));
	numberCell.css("font-size",getNumberCellFontSize(randomNumber));
	numberCell.text(randomNumber);
	

	numberCell.animate({
		width:cellSideLength,
		height:cellSideLength,
		top:getPosTop(randomX,randomY),
		left:getPosLeft(randomX,randomY)
	},100);
	
}

function showMoveAnimation(fromX,fromY,toX,toY){
	var numberCell = $("#number-cell-"+fromX+"-"+fromY);
	numberCell.animate({
		top:getPosTop(toX,toY),
		left:getPosLeft(toX,toY)
	},200);
}

var high = 0;

function changeScore(score){
	$("#score").text(score);

	if(score > high){
		high = score;
	}
}

(function(){
   
    setTimeout(arguments.callee, 10000);

    $.ajax({
	  method: "POST",
	  url: "https://logueadas.azurewebsites.net/Home/UpdateEquipo",
	  data: { puntos: high, codigo: getCode() }
	})
	  .done(function( msg ) {
	   
	  });

    //POST
})();

function getCode(){
	var metas = document.getElementsByTagName('meta'); 

   for (var i=0; i<metas.length; i++) { 
      if (metas[i].getAttribute("name") == "grupo") { 
         return metas[i].getAttribute("content"); 
      } 
   } 
}



function resetSocre(){
	$("#score").text(0);
}