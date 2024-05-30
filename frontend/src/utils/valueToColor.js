export const valueToColor = (value) => {
    if (value == null) {
        return "#808080"
    }
   if (value < 50) {
       return "#FF4545"
   }
    if (value < 70){
        return "#FFA534"
    }
    if (value < 80){
        return "#B7DD29"
    }
    return "#3FA34D" 
}