import suabot from '../assets/suabot.jpg'
import botandam from '../assets/botandam.jpg'
import banhandam from '../assets/banhandam.png'
import topic from '../assets/topic.png'
import topic2 from '../assets/topic2.png'
import topic3 from '../assets/topic3.png'
import topic4 from '../assets/topic4.png'
import topic5 from '../assets/topic5.png'
import topic6 from '../assets/topic6.png'
import { Icon } from '@iconify/react/dist/iconify.js'
import { getCurrentDate } from '../helper/helper'
import { formatCurrency } from '../helpers/helper'

export const DEFAULT_IMG = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSx0pWMi3w72H4-7lvJf5laNUWsZr9bRw1b6Q&s"
export const navbarData = [
    {
        content:"Mua hàng và CSKH 1800 8080",
        link:"/"
    },
    {
        content:"Tìm Siêu Thị (340)",
        link:"/"
    },
    {
        content:"Nhập địa chỉ để mua hàng giao Siêu Tốc 1h",
        link:"/"
    }
]

export const footerData = [
    {
        "Cửa hàng":["Thanh toán tiện lợi","Giao hàng tức thì","Bảo đảm quyền lợi"]
    },
    {
        "Chăm sóc khách hàng":["Tra cứu hoá đơn","Mua & giao nhận Online","Qui định & hình thức thanh toán","Bảo hành & Bảo trì","Đổi trả & Hoàn tiền"]
    },
    {
        "Trang page":["Về chúng tôi","Cửa hàng","Liên hệ","Dịch vụ","Blog"]
    },
]

export const detailProduct = {
    name:"Sữa bột Nubone",
    image:["https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSx0pWMi3w72H4-7lvJf5laNUWsZr9bRw1b6Q&s","https://minizon.vn/wp-content/uploads/2023/04/sua-nubone-plus-chinh-hang.jpg","https://product.hstatic.net/200000500815/product/nubone_s2__5_7fc5725cb9a946278107407e4a3dcf8d_master.jpg","https://cf.shopee.vn/file/5e3c9c4d72227995fe2504de50542a88"],
    from:"sản xuất tại Mỹ",
    price:550000,
    sale:0.1,
    rate:4.8,
    comment:68,
}
export const footerContent1 = "Chào mừng bạn đến với MilMom, lựa chọn tốt nhất cho mẹ và bé!"

export const footerContent2 = "Chúng tôi là một cửa hàng chuyên cung cấp các sản phẩm và dịch vụ đặc biệt để mang đến sức khỏe tốt nhất cho bạn và con của bạn"

export const emptyAvatar =  "https://t4.ftcdn.net/jpg/03/59/58/91/360_F_359589186_JDLl8dIWoBNf1iqEkHxhUeeOulx0wOC5.jpg"

export const homeBanner = [
    {
        content:"Sữa bột",
        imageURL:suabot
    },
    {
        content:"Bột ăn dặm",
        imageURL:botandam
    },
    {
        content:"Bánh ăn dặm",
        imageURL:banhandam
    }
]

export const momMilTopics = [
    {
        content:"Chăm sóc trẻ theo độ tuổi",
        link:"",
        imageURL:topic
    },
    {
        content:"Dinh dưỡng cho bé",
        link:"",
        imageURL:topic2
    },
    {
        content:"Dinh dưỡng cho mẹ bầu",
        link:"",
        imageURL:topic3
    },
    {
        content:"Các bệnh thường gặp ở trẻ em",
        link:"",
        imageURL:topic4
    },
    {
        content:"Khi mẹ mang thai",
        link:"",
        imageURL:topic5
    },
    {
        content:"Thông tin bệnh viện phòng khám",
        link:"",
        imageURL:topic6
    }
]

export const blankAvatar = 'https://t4.ftcdn.net/jpg/03/59/58/91/360_F_359589186_JDLl8dIWoBNf1iqEkHxhUeeOulx0wOC5.jpg'

export const sideBarAdminData = [
    {
        content:"Dashboard",
        icon: <Icon icon="solar:chart-broken" />,
        link:"/dashboard"
    },
    {
        content:"Doanh thu",
        icon: <Icon icon="codicon:book" />,
        link:"/revenueManager"
    },
    {
        content:"Tài khoản",
        icon: <Icon icon="mdi:user" />,
        link:"/userManager"
    },
    {
        content:"Sản phẩm",
        icon: <Icon icon="fluent-mdl2:product" />,
        link:"/statisticalProduct"
    }
]

export const sideBarStaffData = [
    {
        content:"Đơn hàng trong ngày",
        link:"/orderManager"
    },
    {
        content:"Xử Lý Report",
        link:"/reportHandle"
    },
    {
        content:"Bài viết",
        link:"/postManager"
    },
    {
        content:"Slider",
        link:"/slider"
    },
    {
        content:"Yêu cầu tư vấn (chat)",
        link:"/chat"
    }
]

export const sideBarManagerData = [
    {
        content:"Quản lý sản phẩm",
        link:"/productManager"
    },
    {
        content:"Quản lý slider",
        link:"/sliderManager"
    },
    {
        content:"Quản lý danh mục",
        link:"/categoryManager"
    },
    {
        content:"Quản lý bài viết",
        link:"/postManager"
    },
]

export const accountType = [
    {
        content:"Staff"
    },
    {
        content:"Manager"
    },
    {
        content:"Member"
    }
]

export const accountList = [
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        email:"XYZ@GMAIL.COM",
        phone:"0123456789",
        roleId:"ADMIN",
        status:"ACTIVE"
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        email:"XYZ@GMAIL.COM",
        phone:"0123456789",
        roleId:"ADMIN",
        status:"ACTIVE"
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        email:"XYZ@GMAIL.COM",
        phone:"0123456789",
        roleId:"ADMIN",
        status:"ACTIVE"
    }
]

export const orderList = [
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        address:"TP HCM",
        detail:""
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        address:"TP HCM",
        detail:""
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        address:"TP HCM",
        detail:""
    },
]

export const reportList = [
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        content:"giao thiếu sản phẩm",
        detail:""
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        content:"giao thiếu sản phẩm",
        detail:""
    },
    {
        id:"id00001",
        name:"Nguyễn Văn A",
        phone:"0123456789",
        createdDate: getCurrentDate(),
        content:"giao thiếu sản phẩm",
        detail:""
    },
]

export const staticDashboard = [
    {
        icon: <Icon icon="clarity:wallet-line" />,
        content: "Tổng Doanh Thu Trong Tuần",
        value:"totalAmount",
        iconColor:"bg-blue-300",
        format: (value) => formatCurrency(value)
    },
    {
        icon: <Icon icon="bx:coin-stack" />,
        content: "Lợi Nhuận Thu Được Trong Tuần",
        value:"totalProfit",
        iconColor:"bg-yellow-300",
        format: (value) => `${value.toFixed(2)}%`
    },
    {
        icon: <Icon icon="uil:money-withdraw" />,
        content: "Số Lượng Sản Phẩm Bán Ra Trong Tuần",
        value:"totalProducts",
        iconColor:"bg-red-300"
    }
]

export const orderStatus = [
    {
        id:0,
        content:"Chờ thanh toán",
        color:"bg-green-200"
    },
    {
        id:1,
        content:"Chờ xác nhận",
        color:"bg-green-500"
    },
    {
        id:2,
        content:"Đang giao hàng",
        color:"bg-lime-500"
    },
    {
        id:4,
        content:"Đã hoàn tất",
        color:"bg-orange-500"
    },
    {
        id:6,
        content:"Chờ hoàn tiền",
        color:"bg-red-500"
    },
    {
        id:7,
        content:"Yêu cầu trả hàng",
        color:"bg-sky-200"
    },
    {
        id:5,
        content:"Đã hủy",
        color:"bg-pink-100"
    }
]