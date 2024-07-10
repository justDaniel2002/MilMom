export function formatCurrency(amount) {
  return amount.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + " đ";
}

export function objectToPram(obj) {
  var param = "?";
  if (obj) {
    for (const [key, value] of Object.entries(obj)) {
      param+=`${key}=${value}&`
    }
  }
  return param;
}
