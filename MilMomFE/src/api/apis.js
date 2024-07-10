
 const Account = `/account`
export const login = `${Account}/login`
export const register = `${Account}/register`
export const getAllAccount = `${Account}/Get-all-accounts`

const AccountApp = `/AccountApp`
export const getTotalAcc = `${AccountApp}/base/GetTotalAccount`


const Product = `/Product`
export const delProduct=`${Product}`
export const getViewProduct = `${Product}/base/getProducts?sortBy=name&pageIndex=1&pageSize=8`
export const getProductDetail = `${Product}/productDetails`
export const searchProduct = `${Product}/base/search`
export const FilterProduct = `${Product}/base/filter`
export const getForManager = `${Product}/base/getProductsForManager`
export const addForManager =  `${Product}/AddForManagement`
export const updateForManager =  `${Product}/UpdateForManagement`

export const post_del_Cart = `/Cart`
export const get_del_Cart_byAccountId = `${post_del_Cart}`

export const checkout = `/Checkout/createOrder`

 const Order = `/Order`
export const getOrderById = `${Order}/get-order-by-id`
export const getOrderByDate = `${Order}/get-all-orders`
export const updateOrderStatus = `${Order}/update-order-status`
export const getTotalProductOfWeek = `${Order}/adminDashBoard/GetTotalAmountTotalProductsOfWeek`
export const getStaticOrders = `${Order}/adminDashBoard/GetStaticOrders`
export const getTopProductsSoldInMonth = `${Order}/adminDashBoard/GetTopProductsSoldInMonth`
export const getStoreRevenueByMonth= `${Order}/adminDashBoard/GetStoreRevenueByMonth`

const Category = `/category`
export const getAllCate = `${Category}/GetAllCategory`

