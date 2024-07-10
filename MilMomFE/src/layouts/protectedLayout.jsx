import React from 'react'
import { Navigate, Outlet } from 'react-router-dom';
import { useRecoilState } from 'recoil';
import { accountAtom } from '../atom/accountAtom';

export default function ProtectedLayout() {
    const [account, setAccount] = useRecoilState(accountAtom);

  return (
    <>
    {account?<Outlet />:<Navigate to={'/login'}/>}
    </>
  )
}
