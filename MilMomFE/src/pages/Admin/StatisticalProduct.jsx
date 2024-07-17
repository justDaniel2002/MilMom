import React, { useEffect, useState } from 'react'
import ManagerTable, { statisticalProductTable } from '../../components/ManagerTable'
import Pagination from '../../components/Pagination'
import MilMomBtn from '../../components/MilMomBtn'
import { getService } from '../../api/services'
import { getTopProduct } from '../../api/apis'

export default function StatisticalProduct() {
  const [top, setTop] = useState(10)
  const [topProducts, setTopPtoducts] = useState([])

  useEffect(() => {
    getService(`${getTopProduct}/?top=${top}`).then(res => setTopPtoducts(res.data))
  },[top])

  return (
    <div>
          <div className="flex justify-between items-center mb-20">
        <div className="font-medium text-3xl">
        Thống kê sản phẩm bán chạy
        </div>
        <MilMomBtn
          content="Xuất file"
          text="text-white"
          className="rounded-lg"
        />
      </div>

      <div className="rounded-xl overflow-hidden">
      <div className="flex justify-between items-center bg-red-200 py-1 px-5">
          <div className="font-medium text-xl">Bộ lọc</div>
          <div className="flex items-end">
           

            <div className="mr-3 flex items-center">
              <div className=" mb-1 font-medium text-xl mx-2">TOP</div>
              <select className='p-3' onChange={(event) => setTop(event.target.value)} value={top}>
                <option>10</option>
                <option>20</option>
                <option>50</option>
              </select>
            </div>

            <select className="p-3">
              <option>Ngày</option>
              <option>Tuần</option>
              <option>Tháng</option>
            </select>
          </div>
        </div>

        <div className='flex'>
            <div className='w-1/4 px-2 py-2'>
                <div className='text-center py-3 text-lg font-medium bg-red-200 rounded-lg'>Tất cả</div>
            </div>
            <div className='w-1/4 px-2 py-2'><div className='text-center py-3 text-lg bg-red-200 rounded-lg'>Sữa Bột</div></div>
            <div className='w-1/4 px-2 py-2'><div className='text-center py-3 text-lg bg-red-200 rounded-lg'>Bột Ăn Dặm</div></div>
            <div className='w-1/4 px-2 py-2'><div className='text-center py-3 text-lg bg-red-200 rounded-lg'>Bánh Ăn Dặm</div></div>
        </div>

        <div className='px-10 my-10'>
            <ManagerTable datas={topProducts} headerTable={statisticalProductTable} indexHeader={"Top"} isDelete={false} isApprove={false}/>
        </div>

        <Pagination />

        
      </div>
    </div>
  )
}
