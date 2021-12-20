import { Icon } from '@iconify/react';

// ----------------------------------------------------------------------

const getIcon = (name) => <Icon icon={name} width={22} height={22} />;

const sidebarConfig = [
  {
    title: 'Cardápio',
    path: '/dashboard/cardapio',
    icon: getIcon('eva:book-open-outline')
  },
  {
    title: 'Estoque',
    path: '/dashboard/estoque',
    icon: getIcon('eva:car-outline')
  }
];

export default sidebarConfig;
